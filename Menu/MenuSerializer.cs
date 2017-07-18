using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Menu
{
    public static class MenuSerializer
    {
        private static Type foodType = typeof(Food);
        private static MemoryStream stream = null;
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(foodType);
        private static DataContractSerializer xmlSerializer = null;
        private static Food foodItem = null;

        /// <summary>
        /// serialize an object with JSON format
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ShapeToJson(MenuDTO data)
        {
            stream = new MemoryStream();
            jsonSerializer = new DataContractJsonSerializer(foodType);
            jsonSerializer.WriteObject(stream, data);
            byte[] serializedData = stream.ToArray();
            stream.Close();

            return Encoding.UTF8.GetString(serializedData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MenuDTO JsonToShape(string data)
        {
            using (stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                foodItem = jsonSerializer.ReadObject(stream) as Food;
            }
            return foodItem;
        }


    }
}