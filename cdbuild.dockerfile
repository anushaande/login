FROM aanusha/vstest:v1
SHELL ["powershell"]

COPY . 'C:\\build\\'
WORKDIR 'C:\\build\\'
 
RUN ["nuget.exe", "restore"]
RUN ["msbuild", "C:\\build\\HelloWorld.sln"]

CMD ["powershell"]