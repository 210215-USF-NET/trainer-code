# So you wanna build a pipeline

## Setting up a basic pipeline

1. Log in to Azure DevOps (using the same email as your Azure Cloud Services)
2. Create a project (a private one)
   - Private projects have default build agents provided for you by microsoft
   - These agents are vms that you run your pipeline against
   - **Note:** Give your project a meaningful name
3. Once your project is created select the pipeline option on the menu to the left
4. Create a new pipeline, follow the instructions to hook your vcs repo to your pipeline
   - This should scaffold a basic pipeline for you using vsbuild and vstest
   - Choose the ASP.NET Core app as the project template
5. Check to ensure the vm-image being used is the windows-latest
6. Edit the the created pipeline to use dotnet cli commands
   - Use the assistant on the right side of the pipeline editor to scaffold the appropriate tasks for you
   - Make sure to order your build process properly!
     1. Restore
     2. Build
     3. Test
     4. Publish
   - Furthermore, make sure you are pointing to the appropriate projects!
   - If there exists only one solution file in your repository, then you can keep the default settings of each of these tasks
7. Save your pipeline and watch it run!

## Deploying a webapp to app services using pipelines

1. In your dotnet publish task, make sure you set the property zipafterpublish to true
2. Using the task assistant on the right side of your pipeline editor, search for the azure app service deploy task
3. Select your subscription, and authorize your azure devops account to use your resources
4. After authorization, pick the app service that you want to deploy your application to
5. Save your pipeline and watch your app go live!

## Adding code analysis by sonar cloud to your pipeline

1. Log in to your sonar cloud account using **github** (because it's free)
2. Create a project:
   1. Choose the organization
   2. Select the repo
   3. A project should be set up for you
   - Remember the project key and name that you set your project to!
3. Install sonar cloud to your azure devops account
   - Go to this [link](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarcloud)
4. Create a service connection to sonar cloud in azure devops:
   1. Navigate to project settings on the left menu
   2. Under the pipelines section, click on service connections
   3. Select add new service connection
   4. Choose sonar cloud
   5. Input your personal access token to sonar cloud
   - To generate a personal access token to sonar cloud:
     1. Log in to sonar cloud
     2. Click on your profile icon on the upper right corner
     3. Select my acccount
     4. On the account page, select security
     5. Select generate new token
     6. Copy the generated token
   6. Verify the token, name your service connection, and save it
5. Back to your pipeline editor, add a prepare analysis config task before any of the other tasks in your build pipeline
   - When setting up this task:
     1. Select the service connection to your sonar cloud account
     2. Input in your project key and name
        - To find your project key:
          - Go under the administration menu in your project and select the update key
          - If you're unable to access this menu and you're part of an org try using the naming convention OrgName_ProjectName
6. Add a run code analysis task after the test step of the build pipeline
7. Add a publish code analysis task after the run code analysis task
8. Save your pipeline and watch sonar cloud judge your code!

## Publishing code coverage results

**Note:** make sure you have sonar cloud analysis set up in your pipeline to see the results!

1. On your dotnet test task add `arguments: --configuration $(buildConfiguration) --collect "Code Coverage"` under the inputs
2. Set the publish code coverage results after the dotnet test task
3. Search for the publish code coverage results task on the assitant to the right of the pipeline editor
4. Select cobutura as the code coverage tool
5. Set the summary file location to be: `**/coburtura/coverage.xml`
6. Save your piepline and wait to see how much of your code is tested!

## Further reading:

- [YAML Schema for Azure Pipelines](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema)
- [What is Azure Pipelines](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/what-is-azure-pipelines?view=azure-devops)
