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
        commandController = CommandController.getInstance();
        commandSequenceController = CommandSequenceController.getInstance();
        logController = LogController.getInstantce();
        repoConfigController = RepoConfigController.getInstance();
        repositoryController = RepositoryController.getInstance();
        userController = UserController.getInstance();
    }
}