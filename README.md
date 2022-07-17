# deSnap
deSnap is a Windows tool in development that aims to extract .JPGs from the Snapmatic game feature in GTA Online.
## How is it gonna work?
The coded files are located in C:\Users\USERNAME\Documents\Rockstar Games\GTA V\Profiles\ <br>
There should be some files that we don't care about, and the Snapmatic photos, saved as files 
without any extension, starting with PGTA5, followed by some numbers. According to 
[this user on gtaforums.com](https://gtaforums.com/topic/785078-snapmatic-shots/?do=findComment&comment=1067312665). 
the files are image files with 292 bytes of header data. This is verifiable by 
opening the file in a Hex editor and manually deleting the bytes. 
This tool is going to read the binary of the files, delete the header data, and 
save it as .JPG.
## What's the current state
~~As of today I was able to read a binary of a photo file, changing "something" and saving the file again. The thig is, the change the program make is not desirable. When 
deleting the first 292 bytes of the photo file in Hex editor, I was able to get my picture. 
However the binary output of my program is different to the binary output of the Hex editor, 
making the output files of this program unreadable.~~
The imported file is now edited by saving the binary data of original file to an array and 
copying important data to a new array. The program then exports the new array to a .JPEG. Now 
I need to add the functionality to import and export multiple files at once, as you can see 
on the roadmap.
## Roadmap
- [x] Sucessfully load a file
- [x] Sucessfully export a file
- [ ] Load multiple files in single run
- [ ] Export all the files in single run
- [ ] Do some Path magic so the user doesn't have to move any files around 