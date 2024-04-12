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

         //var regione =  context.MaxBy(x => x.Value.Count).Key;

            return regione;
        }

        public List<(string,int)> Duplicate(string path)
        {
            using var data = new Data(path);
            data.Initialize();

            return data.GetAll().SelectMany(x => x.Value)
                .GroupBy(x => x)
                .Where(group => group.Count() > 1)
                .Select(group => ( group.Key,  group.Count() )).ToList();

        }
    }
}
