using Newtonsoft.Json;
using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class AppConfigController
{
    public AppConfig appConfig { get; private set; }

    public static AppConfigController getInstance()
    {
        return instance ?? (instance = new AppConfigController());
    }

    public void Save()
    {
        StreamWriter writerFile = new StreamWriter(confPath);

        string appConfigJson = JsonConvert.SerializeObject(appConfig);

        writerFile.Write(appConfigJson);

        writerFile.Close();

    }

    public void Load()
    {
        StreamReader readerFile = new StreamReader(confPath);

        this.appConfig = JsonConvert.DeserializeObject<AppConfig>(readerFile.ReadToEnd());

        readerFile.Close();
    }

    private static string confPath = AppDomain.CurrentDomain.BaseDirectory + "StachioConf.json";

    private static AppConfigController instance;

    private AppConfigController()
    {
        bool fileExists = File.Exists(confPath);

        if (fileExists)
        {
            Load();
        }

        this.appConfig = AppConfig.getInstance();

        if (!fileExists)
        {
            Save();
        }
    }

    
}
