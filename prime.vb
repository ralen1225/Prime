Public Class Prime
  ' Class definition to generate prime numbers

  ' Array used to store prime numbers as they are generated
  Private Shared aryPrimes As Integer() = {2, 3}

  ' Return the nth prime (2 is the 1st prime)
  Public ReadOnly Property Value(ByVal Index As Integer) As Integer
    Get
      ' The array is 0-based. Adjust Index to compensate
      ' If there are not enough primes generated, add more as needed.
      If Index > aryPrimes.Length Then
        PadArray(Index - 1)
      End If
      ' Return selected prime
      Return aryPrimes(Index - 1)
    End Get
  End Property

  ' Number of prime numbers currently in the array.
  Public ReadOnly Property Length As Integer
    Get
      ' Return length of the array
      Return aryPrimes.Length
    End Get
  End Property

  ' Generate the next prime above the given value.
  Public ReadOnly Property Above(ByVal Limit As Integer) As Integer
    Get
      ' Add more primes until we have a useable number
      Do Until Value(Length) > Limit
        PadArray(Length + 1)
      Loop
      ' Find prime number requested.
      For i As Integer = Length To 1
        If Value(i) <= Limit Then Return Value(i + 1)
      Next
    End Get
  End Property

  ' Find prime number below given number
  Public ReadOnly Property Below(ByVal Limit As Integer) As Integer
    Get
      ' There are no primes below the first one in the list (2)
      If Limit <= Value(1) Then Throw New ArgumentException("Limit too low.")
      ' Add more primes until we have a useable number
      Do Until Value(Length) > Limit
        PadArray(Length + 1)
      Loop
      ' Find requested prime number
      For i As Integer = 1 To Length
        If Value(i) >= Limit Then Return Value(i - 1)
      Next
    End Get
  End Property

  Private Sub PadArray(ByVal Index As Integer)
    Do Until Length > Index
      ' Add a blank entry to the array
      ReDim Preserve aryPrimes(Length)
      ' There is an empty entry at the end of the array. Adjust to compensate.
      aryPrimes(Length - 1) = NextPrime(Value(Length - 1))
    Loop
  End Sub

  ' Find next higher prime number
  Private Function NextPrime(ByVal Start As Integer) As Integer
    ' blnDone indicates successful generation
    Dim blnDone As Boolean = False
    ' Start at next odd number
    Dim intCurrent As Integer = (Start + 1) Or 1
    Do Until blnDone
      ' Set limit for factor checking
      Dim intMaxRoot As Integer = Math.Sqrt(Start)
      ' blnFail indicates current numbewr is not prime
      Dim blnFail As Boolean = False
      ' Start counter
      Dim intCount As Integer = 1
      ' Loop until either failed or done
      Do Until blnFail Or blnDone
        ' Exceeded scope without finding a factor
        If intCount > Length OrElse Value(intCount) > intMaxRoot Then
          blnDone = True
          ' Found a factor
        ElseIf (intCurrent Mod Value(intCount)) = 0 Then
          blnFail = True
        Else
          ' Have not yet found a factor
          intCount += 1
        End If
      Loop
      ' Check next potential prime (skip even numbers)
      If blnFail Then intCurrent += 2
    Loop
    ' Return prime number
    Return intCurrent
  End Function

End Class
