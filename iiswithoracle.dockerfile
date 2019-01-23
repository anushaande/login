FROM aanusha/iisoracle:v1

#Install Chocolatey
RUN @powershell -NoProfile -ExecutionPolicy unrestricted -Command "$env:chocolateyUseWindowsCompression = 'false'; (iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))) >$null 2>&1" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin

# this is where the Oracle ODAC Xcopy version has been unzipped into
WORKDIR c:/install

#install ODP.NET 4 32bit, Microsoft Visual C++ 2010 Redistributable Package, Set path to include oracle home
    RUN @powershell -NoProfile -ExecutionPolicy unrestricted -Command ".\install.bat odp.net4  c:\oracle myhome true;" \ 
        && choco install vcredist2010 -y --allow-empty-checksums; \
        && setx /m PATH "%PATH%;C:\oracle"

# this is where the application is copied to
WORKDIR c:/
	
SHELL ["powershell"]

RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \
    Install-WindowsFeature Web-Asp-Net45
COPY CrossWalk CrossWalk
RUN Remove-WebSite -Name 'Default Web Site'
RUN New-Website -Name 'crossWalk' -Port 80 \
    -PhysicalPath 'c:\CrossWalk' -ApplicationPool '.NET v4.5'
EXPOSE 80

CMD Write-Host IIS Started... ; \
    while ($true) { Start-Sleep -Seconds 3600 }
