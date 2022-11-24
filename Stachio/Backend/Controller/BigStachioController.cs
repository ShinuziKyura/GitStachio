namespace Stachio.Backend.Controller;

public sealed class BigStachioController
{
    public BigStachioController()
    {
        appConfigController = AppConfigController.getInstance();
        commandController = StacheCommandController.GetInstance();
        commandSeqController = StacheCommandSeqController.GetInstance();
        logController = LogController.getInstance();
        repoConfigController = RepoConfigController.getInstance();
        repositoryController = RepositoryController.getInstance();
        userController = UserController.getInstance();
    }

    public void SaveAppConfig() { appConfigController.Save();}

    public void LoadAppConfig() { appConfigController.Load();}

    private AppConfigController appConfigController;
    private StacheCommandController commandController;
    private StacheCommandSeqController commandSeqController;
    private LogController logController;
    private RepoConfigController repoConfigController;
    private RepositoryController repositoryController;
    private UserController userController;
}