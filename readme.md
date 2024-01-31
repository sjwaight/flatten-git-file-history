# Simple Git File History parser

This C# program will parse an exported Git File History and output a CSV file with the following columns:

* Commit SHA
* Change Type
* File Name

This can then be imported into Excel or other tools for analysis.

Requires .NET 6 (any OS is fine).

Start by using the following git command to create a file called `files.txt`.

```bash
git --no-pager log --name-status > files.txt
```

A sample `files.txt` file is included which is orginally from [this solution](https://github.com/codingblocks/git-to-elasticsearch) to import commit history into Elasticsearch.

Once you have the `files.txt` file, and have compiled this program, run the program with the following command:

```bash
flattengitfilehistory files.txt
```

It will produce an output text file called `filtered.csv` which you can then import for analysis.
