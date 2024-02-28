using Newtonsoft.Json;
using Object = System.Object;

namespace Data
{
    public static class SaveLoadManager
    {
        private const string EMPTY_BODY = "{}";
        private static FileManager _fileManager;

        public static void SaveJsonData(Object o, string fileName)
        {
            if (_fileManager == null)
                _fileManager = new FileManager();

            string json = JsonConvert.SerializeObject(o);

            if (json == EMPTY_BODY)
                return;

            _fileManager.WriteToFile(fileName, json);
        }

        public static bool LoadJsonData<T>(string fileName, ref T o)
        {
            if (_fileManager == null)
                _fileManager = new FileManager();

            if (_fileManager.LoadFromFile(fileName, out var json))
            {
                if (json == EMPTY_BODY)
                    return false;

                o = JsonConvert.DeserializeObject<T>(json);
                return true;
            }

            return false;
        }
    }
}