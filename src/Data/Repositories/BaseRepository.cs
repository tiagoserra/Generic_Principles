using Domain.CoreDomain.Entities;
using Domain.CoreDomain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected static IMongoClient _client;

        protected static IMongoDatabase _database;

        protected static IMongoCollection<BsonDocument> _collection;

        public BaseRepository()
        {
            var stringconnection = "mongodb://localhost";
            var dataBase = "GenericController";

            _client = new MongoClient(stringconnection);
            _database = _client.GetDatabase(dataBase);
            _collection = _database.GetCollection<BsonDocument>(typeof(TEntity).Name);

            ConfigurationMongoMapper();
        }

        private void ConfigurationMongoMapper()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity<TEntity>)))
            {
                BsonClassMap.RegisterClassMap<Entity<TEntity>> (cm =>
                {
                    cm.AutoMap();
                    cm.UnmapProperty("ValidationResult");
                    cm.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
                });
            }
        }

        public virtual void Insert(TEntity obj)
        {
            _collection.InsertOne(obj.ToBsonDocument());
        }

        public virtual void Delete(Guid id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            _collection.DeleteOne(filter);
        }

        public virtual void Update(TEntity obj)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", obj.Id);
            var objMongo = _collection.Find(filter).FirstOrDefault();

            if (objMongo != null)
                _collection.ReplaceOne(objMongo, obj.ToBsonDocument());

        }

        public TEntity GetById(Guid id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var obj = _collection.Find(filter).FirstOrDefault();

            if (obj != null)
            {
                obj.Remove("_id");
                return BsonSerializer.Deserialize<TEntity>(obj);
            }

            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var objs = _collection.Find(_ => true).ToList();

            if (objs != null)
            {
                //objs.ForEach(o => o.Remove("_id"));
                return BsonSerializer.Deserialize<IEnumerable<TEntity>>(objs.ToJson());
            }

            return null;
        }
    }
}
