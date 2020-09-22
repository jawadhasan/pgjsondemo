1. Ucomment heat TAG from .csproj
2. Build the installer project
3. find exe file component in components generated and update same component with following code:

              <ServiceInstall Id="InstallWindowsService1" Name="testsvc" DisplayName="PgDemoAppWorker Service"
               Description="pgdemo Jobs"
     Start="auto" ErrorControl="normal" Type="ownProcess" />

              <ServiceControl Id="sc_WindowsService1" Name="testsvc" Start="install" Stop="both" Remove="uninstall" Wait="yes" />
4. Comment HEAT TAG in .csproj
5. Build again