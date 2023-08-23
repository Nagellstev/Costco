pipeline {
    agent any
        parameters {
            choice(name: 'Config', choices: ['DefaultConfig.json', 'FirefoxConfig.json'], description: '')
            credentials(name: 'GitCredentials', defaultValue: 'PasswordJenkins', description: '')
    }

    stages {
        stage('TestSetup') {
            steps {
                echo 'Testing'
                checkout scmGit(branches: [[name: '*/develop']], extensions: [], userRemoteConfigs: [[credentialsId: params.GitCredentials, url: 'https://git.epam.com/filipp_protopopov/epam-at-lab-2023cw36-dotnet/']])
                bat 'dotnet build Costco.sln -t:restore,build -p:RestorePackagesConfig=true'
            }
        }
        stage('Test'){
            parallel{
                stage('ProductPage') {
                    steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% --filter Target=ProductPage  --logger:"xunit;LogFileName=TestResults.xml" --no-build'
                        }
                    }
                    post{
                        always {
                            xunit checksName: '', tools: [xUnitDotNet(excludesPattern: '', pattern: '**/TestResults/*.xml', stopProcessingIfError: false)]
                            archiveArtifacts allowEmptyArchive: true, artifacts: 'Costco.Tests/bin/*/net7.0/logs/screenshots/*.jpeg, Costco.Tests/bin/*/net7.0/logs/*.txt', followSymlinks: false
                        }
                    }
                }
                stage('Delivery') {
steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% --filter Target=Delivery --logger:"xunit;LogFileName=TestResults.xml" --no-build'
                        }
                    }
                    post{
                        always {
                            xunit checksName: '', tools: [xUnitDotNet(excludesPattern: '', pattern: '**/TestResults/*.xml', stopProcessingIfError: false)]
                            archiveArtifacts allowEmptyArchive: true, artifacts: 'Costco.Tests/bin/*/net7.0/logs/screenshots/*.jpeg, Costco.Tests/bin/*/net7.0/logs/*.txt', followSymlinks: false
                        }
                    }
                }
                stage('SearchPage') {
steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% --filter Target=Search --logger:"xunit;LogFileName=TestResults.xml" --no-build'
                        }
                    }
                    post{
                        always {
                            xunit checksName: '', tools: [xUnitDotNet(excludesPattern: '', pattern: '**/TestResults/*.xml', stopProcessingIfError: false)]
                            archiveArtifacts allowEmptyArchive: true, artifacts: 'Costco.Tests/bin/*/net7.0/logs/screenshots/*.jpeg, Costco.Tests/bin/*/net7.0/logs/*.txt', followSymlinks: false
                        }
                    }
                }
                stage('Login') {
steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% --filter Target=Login --logger:"xunit;LogFileName=TestResults.xml" --no-build'
                        }
                    }
                    post{
                        always {
                            xunit checksName: '', tools: [xUnitDotNet(excludesPattern: '', pattern: '**/TestResults/*.xml', stopProcessingIfError: false)]
                            archiveArtifacts allowEmptyArchive: true, artifacts: 'Costco.Tests/bin/*/net7.0/logs/screenshots/*.jpeg, Costco.Tests/bin/*/net7.0/logs/*.txt', followSymlinks: false
                        }
                    }
                }
            }
        }
    }
    post{
        always{
            def issueKeys = jiraIssueSelector(issueSelector: [$class: 'DefaultIssueSelector'])
            jiraComment body: 'test', issueKey: 'issueKeys'
            cleanWs()
        }
    }
}