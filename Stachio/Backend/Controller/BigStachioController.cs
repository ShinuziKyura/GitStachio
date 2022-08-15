namespace Stachio.Backend.Controller;

public sealed class BigStachioController
{
    private AppConfigController appConfigController;
    private CommandController commandController;
    private CommandSequenceController commandSequenceController;
    private LogController logController;
    private RepoConfigController repoConfigController;
    private RepositoryController repositoryController;
    private UserController userController;

    public BigStachioController()
    {
        appConfigController = AppConfigController.getInstance();
        commandController = CommandController.getInstance(appConfigController.AppConfig);
        commandSequenceController = CommandSequenceController.getInstance(appConfigController.AppConfig);
        logController = LogController.getInstantce();
        repoConfigController = RepoConfigController.getInstance(appConfigController.AppConfig);
        repositoryController = RepositoryController.getInstance(appConfigController.AppConfig);
        userController = UserController.getInstance(appConfigController.AppConfig);
    }
}