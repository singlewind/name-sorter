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

## Build and Test
```PowerShell
docker build -t name-sorter .
```

## Run
```PowerShell
docker run -it name-sorter
```
