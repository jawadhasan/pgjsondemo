
 <# 

	This Script, Targets the .NET Core Console Applications in this solution folder.
	It will Build the application, Delete the old Publish folder (if any), Publish new output into specific dist folder (Inside docker directory)
	However, this script can be optimized as it can leverage functions for common tasks
 #>
 
 
 
#Calling deleteservice script
 & .\deleteservice.ps1


#Variables
 $svcName = "PgdemoApp.DataWorker"
 $appName = "PgdemoApp.DataWorker.exe"
 $binPath= "${pwd}" + "\" + $appName 
 
 #Create and start window service
Write-Host "Create and start Window-service" -ForegroundColor Green
sc.exe create $svcName BinPath= $binPath | Out-String #c:\app\PgdemoApp.DataWorker.exe 
sc.exe start $svcName | Out-String

Write-Host ===================================================================================================== -ForegroundColor Red