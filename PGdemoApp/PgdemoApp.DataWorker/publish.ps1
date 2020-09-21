
 <# 

	This Script, Targets the .NET Core Console Applications in this solution folder.
	It will Build the application, Delete the old Publish folder (if any), Publish new output into specific dist folder (Inside docker directory)
	However, this script can be optimized as it can leverage functions for common tasks
 #>
 
 #Variables
 $AppSourcePath = "PgdemoApp.DataWorker.csproj" 
 $AppPublishPath =  Join-Path -Path ${pwd} -ChildPath "/dist-folder"
 
 Write-Host "Publis Script: Working-Dir" ${pwd} -ForegroundColor Yellow 
 
 #Calling deleteservice script
 & .\deleteservice.ps1
 
 Write-Host ***********************BackgroundWorker Publishing*********************************************** -ForegroundColor Red
 
 #Delete App publish folder
 Write-Host "Deleting App Publish-Path:" $AppPublishPath -ForegroundColor Yellow
 Remove-Item -Recurse -Force $AppPublishPath -ErrorAction Ignore
 

 #Publish App
 Write-Host "Publishing App Publish-Path:" $AppPublishPath -ForegroundColor Green 
 dotnet publish $AppSourcePath -c debug -r win-x64 /p:PublishSingleFile=true -o $AppPublishPath
 
  #Copy powershell script files here (dist-folder is already created at this point)
 Copy-Item ".\startservice.ps1" -Destination $AppPublishPath #"C:\Presentation"
 Copy-Item ".\deleteservice.ps1" -Destination $AppPublishPath #"C:\Presentation"
  
 
Write-Host ===================================================================================================== -ForegroundColor Red
