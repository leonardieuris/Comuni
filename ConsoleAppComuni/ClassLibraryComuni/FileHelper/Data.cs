using System.Text;
using ClassLibraryComuni.DTO;

namespace ClassLibraryComuni.FileHelper
{
    public class Data : IDisposable
    {
        private readonly string _path;
        private readonly Dictionary<string, List<string>> _data;

        public Data(string path)
        {
            _path = path;
            _data = new Dictionary<string, List<string>>();
        }

        public void Initialize()
        {
            var allStrings = File.ReadAllLines(_path, Encoding.Latin1);

            foreach (var item in allStrings.Skip(3))
            {
                var elements = item.Split(";");
                var comune = new Comune
                {
                    NomeComune = elements[6],
                    NomeRegione = elements[10]
                };

                SetComune(comune);
            }
        }

        private void SetComune(Comune comune)
        {
            if (!_data.ContainsKey(comune.NomeRegione))
                _data.Add(comune.NomeRegione, new List<string> { comune.NomeComune });

            else _data[comune.NomeRegione].Add(comune.NomeComune);
        }

        public Dictionary<string, List<string>> GetAll() => _data;

        public List<string> GetAllComunebyRegione(string regione) => _data[regione];




        public void Dispose()
        {
            _data.Clear();
        }
    }
}
