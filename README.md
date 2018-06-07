# GlobalX Coding Assessment Solution

## The Goal: Name Sorter

Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person may have. A
name must have at least 1 given name and may have up to 3 given names.

## Assessment Criteria
We will execute your submission against a list with a thousand names

## Thought
1. We need a special string *comparer* to compare the last segment, then pairing other segments.
2. The maxium pairs of given name is 3, we can set the boundry. So, we won't waste more computer power even the name from both side is longer than 3 segements.
3. The criteria is can be used on a thousand names. Each C# character is 16bit. Assume each name is not longer than 100 characters. So, one thousand name is 200KB if we load them in memory. Considering performance, we can finish all the comparing in memory. If we need process large amount of data, I will suggest split files before compare then merge to control the memory usage.
4. Choose docker builder over another vendors for independant.

## Build and Test
If you build code directly, you need .NET Core SDK 2.1 installed. For [installtion](https://www.microsoft.com/net/learn/get-started/windows)

Or, if you have docker installed, you can use following command to build without SDK.

```PowerShell
docker build -t name-sorter .
```

## Run
Copy *unsorted-names-list.txt* to output folder
```sh
docker run -it --rm -v $(pwd)/output:/output name-sorter
```

for Windows, if above doesn't work, you can try
```PowerShell
docker run -it --rm -v ${PWD}\output:/output name-sorter
```
for Command window
```PowerShell
docker run -it --rm -v %cd%\output:/output name-sorter
```

## Future Improvement
1. Make self-contained distribution will simplify the deployment
2. Build targets multiple os
3. Integrate versioning into build system
4. Move the interfaces to NameSorter.Abastraction
5. Move the implementaion to NameSorter.Services
6. Implement async interface instead of sync to improve performance in shared environment
7. Imporve comment in code to be more consistent and fluent


## Cleanup dangling images
Since the docker builder file is multi-stage build file, it will create a lot of intermediate images to optimize build speed and footprint of image. To clean up these dangling images
```Powershell
docker rmi $(docker image ls -q -f dangling=true)
```

