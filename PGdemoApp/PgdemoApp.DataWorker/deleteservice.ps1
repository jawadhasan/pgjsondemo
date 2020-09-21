
 <# 

	This Script, Targets the .NET Core Console Applications in this solution folder.
	It will Build the application, Delete the old Publish folder (if any), Publish new output into specific dist folder (Inside docker directory)
	However, this script can be optimized as it can leverage functions for common tasks
 #>
 
 #Variables
 $svcName = "PgdemoApp.DataWorker" 
 
 sc.exe stop $svcName | Out-String #https://stackoverflow.com/questions/1741490/how-to-tell-powershell-to-wait-for-each-command-to-end-before-starting-the-next
 sc.exe delete $svcName | Out-String
 Write-Host "service cleanup done" -ForegroundColor Yellow 
