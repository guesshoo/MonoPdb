//Reference: http://blog.ctaggart.com/2013/03/assembly-to-pdb-to-source-files.html

let workingDir = sprintf @"%s\bin\debug" __SOURCE_DIRECTORY__
System.Environment.CurrentDirectory <-  workingDir
printfn "%s " workingDir;

#I @"C:\workdir\3rdParty\MonoPdb\MonoPdb\MonoPdb\bin\debug"
#r "Mono.Cecil.dll"
#r "MonoPdb.dll"

open FOO.PdbReader;;


let dllPath = @"C:\WorkDir\git\simpliciti.configurationManager\fixtures\Simpliciti.ConfigurationManager.dll"

let fileName, guid = readPdbInfo dllPath
printfn "%s %A" fileName guid