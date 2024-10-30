 using System.ComponentModel.DataAnnotations;
 
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Strategy.Models
{
    public class Product
	{
		[BsonId]  //mongoDB için 
		[Key]
		[BsonRepresentation(BsonType.ObjectId)] //mongoDB için 
        public string ID { get; set; }
		public string Name { get; set; }


        [BsonRepresentation(BsonType.Decimal128)] //mongoDB için 
        [Column(TypeName ="decimal(18,2")]
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public string UserID { get; set; }

        [BsonRepresentation(BsonType.DateTime)] //mongoDB için 
        public DateTime CreatedDate { get; set; }

	}
}

