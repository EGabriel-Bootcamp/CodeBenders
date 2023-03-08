using sav_bank.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace sav_bank.data
{
     public class DataBase
    {
        public static bool AddData(Bank model, string fileName)
        {
            try
            {
                var currentData = GetData(fileName);
                currentData.Add(model);

                var options = new JsonSerializerOptions { WriteIndented = true };

                string stringJson = JsonSerializer.Serialize(currentData, options: options);
                File.WriteAllText(fileName, stringJson);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
          

        }

        public static bool Update(Bank model, string fileName)
        {
            try
            {
                var currentData = GetData(fileName);

              var index =  currentData.IndexOf(model);
                currentData[index] =model;

                var options = new JsonSerializerOptions { WriteIndented = true };

                string stringJson = JsonSerializer.Serialize(currentData, options: options);
                File.WriteAllBytes(fileName, new byte[0]);
               File.WriteAllText(fileName, stringJson);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }


        }


        public static List<Bank> GetData(string fileName)
        {

            try
            {
                string jsonString = File.ReadAllText(fileName);
                List<Bank> bank = JsonSerializer.Deserialize<List<Bank>>(jsonString);
                if (bank != null)
                {
                    return bank;
                }

                return new List<Bank>();

            }
            catch (System.Exception)
            {

                return new List<Bank>();
            }
           
        }

         public  static Bank GetDataByUserId(string userId, string fileName)
        {

            var currentData = GetData(fileName);
            if (currentData.Any())
            {
                var userData = currentData.SingleOrDefault(x => x.UserName == userId);

                return userData;
            }
            else
            {

                return null;    
            }
        }
    }
}
