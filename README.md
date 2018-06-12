# Prime
Class structure to generate prime numbers. This is an empty class except for the private array which is shared among all of its instances.

Public Properties:
Value Integer
  Returns nth prime
  e.g.: 1st prime is 2
        2nd prime is 3
Length Integer
  Returns number of primes found during current program running.
  Class structure keeps an array of generated primes to speed up processing for subsequent requests.
Above Integer
  Returns next prime that is above specified number
  Will not return same number as its arguement.
Below Integer
  Returns next prime that is below specified number.
  Will not return same number as its arguement.
  
Private Subroutines:
PadArray
  Adds elements to the array of prime numbers until it reaches the size specified
NextPrime Integer
  Finds the prime number above the specified number
