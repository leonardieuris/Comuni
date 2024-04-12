using System.Collections.Generic;
using System.IO;
using ClassLibraryComuni.FileHelper;

namespace ClassLibraryComuni
{
    public class Stat
    {
        public string GetRegioneWithMoreComune(string path)
        {
            using var data = new Data(path);
            data.Initialize();
            var context = data.GetAll();
            var val = 0;
            var regione = string.Empty;

            foreach (var item in context)
            {
                if (item.Value.Count > val)
                {
                    regione = item.Key;
                    val = item.Value.Count;
                }
            }

         //var regione =  context.MaxBy(pair => pair.Value.Count).Key;

            return regione;
        }

        public void Duplicate(string path)
        {
            using var data = new Data(path);
            data.Initialize();
            var context = data.GetAll();
            var myList = new Dictionary<string, int>();
        

            foreach (var item in context)
            {
                if (myList.ContainsKey(item.Key))
                    myList[item.Key]++;
                else myList.Add(item.Key,1);

            }
            
        }
    }
}
