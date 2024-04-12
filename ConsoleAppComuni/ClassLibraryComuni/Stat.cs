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
                regione = item.Value.Count > val ? item.Key : regione;
            }

            return regione;
        }
    }
}
