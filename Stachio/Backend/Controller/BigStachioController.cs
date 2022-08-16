namespace Stachio.Backend.Controller;

public sealed class BigStachioController
{
    public BigStachioController()
    {
        appConfigController = AppConfigController.getInstance();
        commandController = CommandController.getInstance();
        commandSequenceController = CommandSequenceController.getInstance();
        logController = LogController.getInstance();
        repoConfigController = RepoConfigController.getInstance();
        repositoryController = RepositoryController.getInstance();
        userController = UserController.getInstance();
    }

    

    private AppConfigController appConfigController;
    private CommandController commandController;
    private CommandSequenceController commandSequenceController;
    private LogController logController;
    private RepoConfigController repoConfigController;
    private RepositoryController repositoryController;
    private UserController userController;
}