# deSnap
deSnap is a Windows tool in development that aims to extract .JPGs from the Snapmatic game feature in GTA Online.
## How does it work?
The coded files are located in C:\Users\USERNAME\Documents\Rockstar Games\GTA V\Profiles\CODE\ <br>
USERNAME being your user name (duh) and CODE being a random code named folder inside of the Profiles directory.<br>
There should be some files that we don't care about, and the Snapmatic photos, saved as files 
without any extension, starting with PGTA5, followed by a string of numbers. According to 
[this user on gtaforums.com](https://gtaforums.com/topic/785078-snapmatic-shots/?do=findComment&comment=1067312665). 
the files are image files with 292 bytes of header data. This is verifiable by 
opening the file in a Hex editor and manually deleting the bytes. 
This tool finds its path to the right folder, selects the correct files, and one by one it strips each file of the
unwanted bytes. Then it exports all of the pictures to a new folder on users desktop. Simple as that. You don't 
need to manually input anything, or look for the right folders.
## What's the current state
The program seems to be working fine. The naming of the output files is kinda wonky, I might have to change that later.
I have yet to test it somewhere other than my computer.
## Roadmap
- [x] Sucessfully load a file
- [x] Sucessfully export a file
- [x] Load multiple files in single run
- [x] Export all the files in single run
- [x] Do some Path magic so the user doesn't have to move any files around 