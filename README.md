# PC Gamepass Save File Container Analyzer

In PC Gamepass, user save files grouped and stored in different folders called "container". Each container contains one or more save files along with a container index. Save files in container use an uppercase GUID filename which is hard to recognize and backup.  

This tool is modified from [Fr33dan/GPSaveConverter](https://github.com/Fr33dan/GPSaveConverter) and allows user to read container indices for dumping save files.

The root folder of PC Gamepass save file is `%LOCALAPPDATA%\Packages\Microsoft.624F8B84B80_8wekyb3d8bbwe\SystemAppData\wgs\[USERID]-[RANDOMSTRING]`. Multiple root folders may be used by PC Gamepass.

```
- [root]
  - AAAAAAAAAAAAAAAA_BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    - CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
      - container.[number]
      - DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
      - ...
```