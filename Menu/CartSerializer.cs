using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using MenuProjectDAL;

namespace MenuProject
{
    class CartSerializer
    {
        private static Type cartItemType = typeof(CartItem);
        private static MemoryStream stream = null;
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(cartItemType);
        private static CartItem cartItem = null;

        /// <summary>
        /// serialize an object with JSON format
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string CartToJson(CartDTO data)
        {
            stream = new MemoryStream();
            jsonSerializer = new DataContractJsonSerializer(cartItemType);
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
        public static CartDTO JsonToCart(string data)
        {
            using (stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                cartItem = jsonSerializer.ReadObject(stream) as CartItem;
            }
            return cartItem.convertCartToDTO();
        }
    }
}
