' Sistema de cifrado.

' Este es el código origen de la librería de enlace dinámico seguridadDLL

Imports System.IO
Imports System.Security.Cryptography
Imports System.Text  ' Sí es necesario para Encoding
Public Class Seguridad
    Private key() As Byte = {}
    Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

    Public Function DesencriptarVB(ByVal stringToDecrypt As String,
        ByVal sEncryptionKey As String) As String
        Dim inputByteArray(stringToDecrypt.Length) As Byte
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(sEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            'Esta línea se añade para que funcione la longitud de las cadenas correctamente.
            stringToDecrypt = stringToDecrypt.Replace(" ", "+")

            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV),
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function

    Public Function EncriptarVB(ByVal stringToEncrypt As String,
        ByVal SEncryptionKey As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(SEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(
                stringToEncrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV),
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function

End Class

