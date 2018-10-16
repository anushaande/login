FROM aanusha/vstest:v1
SHELL ["powershell"]

COPY . 'C:\\build\\'
WORKDIR 'C:\Program Files\PackageManagement\NuGet\Packages\Microsoft.TestPlatform.15.8.0\tools\net451\Common7\IDE\Extensions\TestPlatform\'
	
RUN cd 'C:\Program Files\PackageManagement\NuGet\Packages\Microsoft.TestPlatform.15.8.0\tools\net451\Common7\IDE\Extensions\TestPlatform\'
RUN .\vstest.console.exe "C:\build\log-in_component.Test\bin\Release\log-in_component.Test.dll"
#RUN .\vstest.console.exe "C:\build\HelloWorld.Tests\HelloWorld.Tests.csproj /TestAdapterPath:C:\build\HelloWorld.Tests\bin\Debug"

#RUN setx /M PATH $($Env:PATH + ';C:\Program Files\PackageManagement\NuGet\Packages\Microsoft.TestPlatform.15.8.0\tools\net451\Common7\IDE\Extensions\TestPlatform\');

#ENV VSTEST_PATH 'C:\Program Files\PackageManagement\NuGet\Packages\Microsoft.TestPlatform.15.8.0\tools\net451\Common7\IDE\Extensions\TestPlatform\vstest.console.exe'

#RUN ["vstest.console.exe" , "C:\build\HelloWorld.Tests\bin\Debug\HelloWorld.Tests.dll"]

CMD ["powershell"]