using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDB.Models
{

    public class Book : MongoDocBase
    {
        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }

    public class MongoDocBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //需要注意的是：MongoDB存储时间类型数据时，都是先转换为UTC时间，然后存储到数据库中。
        //当我们取出存储的时间时，就会出现时差的问题。因此，一般我们会给文档中的日期类型加上如下所示的注解，将它转换为本地时间传输：
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreatedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
    }
}
