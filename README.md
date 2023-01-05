# VCTableTools

VCTableTools is a Dotnet Standard 2.0 assembly meant to add functions for working with table data from within VisualCron. While VisualCron does have some very good tools for working with table data they are somewhat limited in scope. Currently VCTableTools can only be used for searching within table data from Excel or comma delimited files, but this may change in the future.

## Features

- Searches by column for values that either exactly or partially match a search term.
- Returns either a simple comma separated list of the found cell locations (A12, C12, etc.), or a complex XML object that can be used for a refined search.
- Can be used to search .xls, .xlsx, and .csv files without changing the method call.
- Creates a human readable message that can be passed into an email body.

## Usage
### Currently VCTableTools supports the following public Class/Methods:
| Class | Method | Description |
| ----- | ------ | ----------- |
| TableSearcher | FindExact | Find any exact matches in a given column of a given Excel or CSV file. |
| TableSearcher | FindIn | Find any partial matches in a given column of a given Excel or CSV file (For example 'shing' in 'Washington'. |
| TableSearcher | FindStartsWith | Find any partial matches where the cell value begins with the search term in a given column of a given Excel or CSV file (For example 'Wash' in 'Washington'. |
| TableSearcher | FindEndsWith | Find any partial matches where the cell value ends with the search term in a given column of a given Excel or CSV file (For example 'ton' in 'Washington'. |
| TableHandler | GetAllData | Gets all of the data from a sheet in an Excel or CSV file. |
| ExcelAddressManager | GetRow | Extracts the row number as a string from an Excel format address. For example 'A12' would give you '12' |
| ExcelAddressManager | GetColumn | Extracts the column letter from an Excel address. For example 'A' from 'A12'. |

The TableSearcher methods each have an additional overload. Version 1 is meant for loading data from a standalone file, whereas version 2 is meant for using a previous output as the input for a new search.
### Version 1
| Parameter | Description |
| -------- | ----------- |
| path | The path of the Excel or CSV file. |
| sheetName | The name of the sheet to be searched. Ignored if the file is a CSV file. |
| searchColumn | The column letter to be searched. |
| searchTerm | A string that must be matched exactly to result in a 'hit'. |

### Version 2
| Parameter | Description |
| -------- | ----------- |
| tableString | The Output from a previous search returned as an XML representation (for example {TASK(efa38047-151d-4bca-92b9-5a140e21184b\|StdOut)}) |
| searchColumn | The column letter to be searched. |
| searchTerm | A string that must be matched exactly to result in a 'hit'. | 

With the exception of the two ExcelAddressManager methods all of the methods returns a FindResponse object. If the output in VisualCron is set to 'ToString representation of output' a simple comma separated list of the cell addresses that were found will be output ('A2', 'A21', 'A85'). If the output is set to 'XML representation of object' the following properties will be represented:

### FindResponse Properties
| Property | Dotnet Data Type | Description |
| -------- | ---------------- | ----------- |
| Success | bool | A boolean representing the success of the search. True means at least 1 'hit', and False means none. |
| Message | string | A human readable response message (ie. 'Two instances found') |
| Rows | List<List\<TableCell\>> | A list of a list of TableCells with the contents of the rows where the searched value was found. |
| Addresses | List\<string\> | A list of the cell locations in Excel format (eg. "A1", "D3") where the searched value was found. |

### TableCell Properties
| Property | Dotnet Data Type | Description |
| -------- | ---------------- | ----------- |
| Value | string | The contents of the cell as a string. |
| ColumnLetter | string | The column letter of the cell as if it were an Excel file (A,B,C etc.) |
| ColumnNumber | int | The 1-based index of the column of the cell. |
| RowNumber | int | The 1-based index of the row of the cell. |
| ColumnHeader | string | The column header (if applicable) for the cell. If the file does not have column headers this should be ignored as it will simply take the first row value and turn it into a 'column header'. |
| ExcelAddress | string | The Excel formated address of the cell (eg. 'A12').

# Example Usage
The results of calling 
```c# 
VisualCronTableTools.FindExact(path='c:\testdata.xls', sheetName='Sheet1', searchColumn='D', searchTearm='Virginia')
```

on the follwing table:
|  | A | B | C | D | E |
| - | - | - | - | - | - |
| 1 | Name | Address | City | Province/State  | Postal Code/ZIP |
| 2 | Bob Smith | 118 Riverside | Clarington | Virginia | 20301 |
| 3 | Claire Brown | 22 Ridge Crescent | Littletown | Virginia | 22202 |
| 4 | Roger Smith | 44 South Street | South Bend | Ontario | K1A 5P0 |

would return the following XML output:
```xml
<?xml version="1.0" encoding="utf-8"?>
<FindResponse xmlns:xsd="http://www.w3.org/2001/XMLSchema"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <Success>true</Success>
    <Message>2 match(es) found.</Message>
    <Rows>
        <Row>
            <TableCell>
                <Value>Bob Smith</Value>
                <ColumnLetter>A</ColumnLetter>
                <ColumnNumber>1</ColumnNumber>
                <RowNumber>2</RowNumber>
                <ColumnHeader>Name</ColumnHeader>
                <ExcelAddress>A2</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>118 Riverside</Value>
                <ColumnLetter>B</ColumnLetter>
                <ColumnNumber>2</ColumnNumber>
                <RowNumber>2</RowNumber>
                <ColumnHeader>Address</ColumnHeader>
                <ExcelAddress>B2</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>Clarington</Value>
                <ColumnLetter>C</ColumnLetter>
                <ColumnNumber>3</ColumnNumber>
                <RowNumber>2</RowNumber>
                <ColumnHeader>City</ColumnHeader>
                <ExcelAddress>C2</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>Virginia</Value>
                <ColumnLetter>D</ColumnLetter>
                <ColumnNumber>4</ColumnNumber>
                <RowNumber>2</RowNumber>
                <ColumnHeader>Province/State</ColumnHeader>
                <ExcelAddress>D2</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>20301</Value>
                <ColumnLetter>E</ColumnLetter>
                <ColumnNumber>5</ColumnNumber>
                <RowNumber>2</RowNumber>
                <ColumnHeader>Postal Code/ZIP</ColumnHeader>
                <ExcelAddress>E2</ExcelAddress>
            </TableCell>
        </Row>
        <Row>
            <TableCell>
                <Value>Claire Brown</Value>
                <ColumnLetter>A</ColumnLetter>
                <ColumnNumber>1</ColumnNumber>
                <RowNumber>3</RowNumber>
                <ColumnHeader>Name</ColumnHeader>
                <ExcelAddress>A3</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>22 Ridge Crescent</Value>
                <ColumnLetter>B</ColumnLetter>
                <ColumnNumber>2</ColumnNumber>
                <RowNumber>3</RowNumber>
                <ColumnHeader>Address</ColumnHeader>
                <ExcelAddress>B3</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>Littletown</Value>
                <ColumnLetter>C</ColumnLetter>
                <ColumnNumber>3</ColumnNumber>
                <RowNumber>3</RowNumber>
                <ColumnHeader>City</ColumnHeader>
                <ExcelAddress>C3</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>Virginia</Value>
                <ColumnLetter>D</ColumnLetter>
                <ColumnNumber>4</ColumnNumber>
                <RowNumber>3</RowNumber>
                <ColumnHeader>Province/State</ColumnHeader>
                <ExcelAddress>D3</ExcelAddress>
            </TableCell>
            <TableCell>
                <Value>22202</Value>
                <ColumnLetter>E</ColumnLetter>
                <ColumnNumber>5</ColumnNumber>
                <RowNumber>3</RowNumber>
                <ColumnHeader>Postal Code/ZIP</ColumnHeader>
                <ExcelAddress>E3</ExcelAddress>
            </TableCell>
        </Row>
    </Rows>
    <Addresses>
        <Address>D2</Address>
        <Address>D3</Address>
    </Addresses>
</FindResponse>
```
This output could then be used as the input for a new search, such as  
```c# 
VisualCronTableTools.FindEndsWith(tableString={TASK(efa38047-151d-4bca-92b9-5a140e21184b|StdOut)}, searchColumn='A', searchTearm='Virginia')
```
Which if output with 'ToString representation of output' chosen in VisualCron would return 'A2' as its output.


