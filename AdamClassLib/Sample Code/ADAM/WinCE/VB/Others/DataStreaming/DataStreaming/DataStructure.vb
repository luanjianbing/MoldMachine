Public Class DataStructure
    Private byData() As Byte

    Public Sub New()
        'ToDO : Add constructor logic here
    End Sub

    Public Sub SetData(ByVal i_byData() As Byte, ByVal iLen As Integer)
        ReDim Preserve byData(iLen)
        Array.Copy(i_byData, 0, byData, 0, iLen)
    End Sub

    Public Function Header() As UInt32
        Return BitConverter.ToUInt32(byData, 0)
    End Function

    Public Function CommandType() As Byte
        Return byData(4)
    End Function

    Public Function DataLength() As Byte
        Return byData(5)
    End Function

    Public Function DIO(ByVal i_iIndex As Integer) As UInt16
        Dim iData As UInt16
        iData = byData(i_iIndex * 2 + 7)
        iData = Convert.ToUInt16(iData * 256 + byData(i_iIndex * 2 + 6))
        Return iData
    End Function

    Public Function AIO(ByVal i_iIndex As Integer) As UInt16
        Dim iData As UInt16
        iData = byData(i_iIndex * 2 + 22)
        iData = Convert.ToUInt16(iData * 256 + byData(i_iIndex * 2 + 23))
        Return iData
    End Function

End Class
