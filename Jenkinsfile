pipeline {
    agent any
        parameters {
            booleanParam(name: 'ProductPage', defaultValue: true)
            booleanParam(name: 'Delivery', defaultValue: true)
            booleanParam(name: 'SearchPage', defaultValue: true)
            booleanParam(name: 'Login', defaultValue: true)
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
                checkout scmGit(branches: [[name: '*/develop']], extensions: [], userRemoteConfigs: [[credentialsId: '7f522695-e5e9-408c-acfa-8521b0bd0bc0', url: 'https://git.epam.com/filipp_protopopov/epam-at-lab-2023cw36-dotnet/']])
                bat 'msbuild Costco.sln -t:restore,build -p:RestorePackagesConfig=true'
            }
        }
        stage('ProductPage') {
            when {
                expression { return params.ProductPage }
            }
            steps {
                bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\DefaultConfig.json -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\ProductPageTestData.json --filter Target=ProductPage  --logger:"xunit;LogFileName=TestResults.xml" --no-build'
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
                bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\DefaultConfig.json -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\LocationsTestData.json --filter Target=Delivery --logger:"xunit;LogFileName=TestResults.xml" --no-build'
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
                bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\DefaultConfig.json -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\SearchPageTestData.json --filter Target=Search --logger:"xunit;LogFileName=TestResults.xml" --no-build'
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
                bat 'dotnet test Costco.Tests\\Costco.Tests.csproj -e: Config=%WORKSPACE%\\Costco.TestData\\Config\\DefaultConfig.json -e: TestData=%WORKSPACE%\\Costco.TestData\\TestData\\LoginCredentialsTestData.json --filter Target=Login --logger:"xunit;LogFileName=TestResults.xml" --no-build'
            }
            post{
                always {
                    xunit checksName: '', tools: [xUnitDotNet(excludesPattern: '', pattern: '**/TestResults/*.xml', stopProcessingIfError: false)]
                    archiveArtifacts allowEmptyArchive: true, artifacts: 'Costco.Tests/bin/*/net7.0/logs/screenshots/*.jpeg, Costco.Tests/bin/*/net7.0/logs/*.txt', followSymlinks: false
                }
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying'
            }
        }
    }
    post{
    always{
        cleanWs()
    }
    }
}