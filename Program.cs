using System.Text.RegularExpressions;

// create the files.txt file by running the following command in the git repo
// git --no-pager log --name-status > files.txt
var lines = File.ReadAllLines("files.txt");
var resultLines = new List<string>() { "commit,change_type,file_path" };

var commitLines = new List<string>();
var commitHash = string.Empty;

foreach (var line in lines)
{
    // we are at the start of a new commit
    if (line.StartsWith("commit"))
    {
        // if we have any lines from the previous commit, add them to the result
        // and clear the list
        if(commitLines.Count > 0)
        { 
            resultLines.AddRange(commitLines);
            commitLines = new List<string>();
        }
        commitHash = line[7..];
    }

    // if we have a file change line, add it to the list
    if(Regex.IsMatch(line, @"^(A|C|D|M|R|T|U|X|B)\t"))
    {
        // get the action type and file path
        var changeType = line[0];
        var filePath = line[2..].TrimStart();

        // add the line to the list
        commitLines.Add($"{commitHash},{changeType},{filePath}");
    }
}

File.WriteAllLines("filtered.csv", resultLines);