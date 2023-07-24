pipeline {
    agent any
        parameters {
            booleanParam(name: 'ProductPage', defaultValue: true)
            booleanParam(name: 'Delivery', defaultValue: true)
            booleanParam(name: 'SearchPage', defaultValue: true)
            booleanParam(name: 'Login', defaultValue: true)
            choice(name: 'Config', choices: ['DefaultConfig.json', 'FirefoxConfig.json'], description: '')
            credentials(name: 'GitCredentials',description: '')
    }

    stages {
        stage('Build') {
            steps {
                echo 'Building'
            }
        }
        stage('TestSetup') {
            steps {
                echo 'Testing'
                checkout scmGit(branches: [[name: '*/develop']], extensions: [], userRemoteConfigs: [[credentialsId: params.GitCredentials, url: 'https://git.epam.com/filipp_protopopov/epam-at-lab-2023cw36-dotnet/']])
                bat 'msbuild Costco.sln -t:restore,build -p:RestorePackagesConfig=true'
            }
        }
        stage('Test'){
            parallel{
                stage('ProductPage') {
                    when {
                        expression { return params.ProductPage }
                    }
                    steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\ProductPageTestData.json --filter Target=ProductPage  --logger:"xunit;LogFileName=TestResults.xml" --no-build'
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
                    when {
                        expression { return params.Delivery }
                    }
                    steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\LocationsTestData.json --filter Target=Delivery --logger:"xunit;LogFileName=TestResults.xml" --no-build'
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
                    when {
                        expression { return params.SearchPage }
                    }
                    steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\SearchPageTestData.json --filter Target=Search --logger:"xunit;LogFileName=TestResults.xml" --no-build'
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
                    when {
                        expression { return params.Login }
                    }
                    steps {
                        catchError(buildResult: 'UNSTABLE', stageResult: 'FAILURE'){
                        bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\%Config% -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\LoginCredentialsTestData.json --filter Target=Login --logger:"xunit;LogFileName=TestResults.xml" --no-build'
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
            cleanWs()
        }
        success{
            echo 'Deploying'
        }
        unstable{
            echo 'Not deploying'
        }
    }
}