# log2excel
##Console tool to convert Apache HTTP log file to Excel-compatible CSV file

Sometimes I am interested to look at a raw HTTP log of a website. It is much more convenient to analize such files when they are loaded into an Excel spreadsheet. It's just needed to convert the log file to CSV format, isn't? But Excel does not follows CSV standard by default... So, I've made this very simple tool to convert log files into Excel-compatible CSV.

![log in Excel](http://szyryanov.github.io/Portfolio/log2excel/img/log-in-excel.png)

##Usage
1. Download `log2excel.zip` from [Releases](https://github.com/szyryanov/log2excel/releases) page, unpack the zip
2. `log2excel.exe log_file_name`
3. Double-click the produced `log_file_name.csv` file to open it in Excel

#Compatibility
- Built for .NET 2.0, so must works in any Windows starting from XP (tested for Windows 7)
- Tested for Excel 2007
