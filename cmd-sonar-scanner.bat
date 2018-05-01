cd src
dotnet "../sonar-scanner/SonarScanner.MSBuild.dll" begin /k:"Swastika.Core" /o:"swastika-io" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="6a483423ddd398c2cdd23d61937594db76709ec4" /d:sonar.exclusions="**/wwwroot/lib/**,**/*.jpg,**/*.png,**/*.svg,**/*.xml" /d:sonar.coverage.exclusions="/**"

dotnet build

dotnet "../sonar-scanner/SonarScanner.MSBuild.dll" end /d:sonar.login="6a483423ddd398c2cdd23d61937594db76709ec4"