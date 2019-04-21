## Debug later/Test After/Test Driven Development(TDD)

Grenning talks about three different methods of testing that are done in his book *Test Driven Development for Embedded C*.

### Debug Later
There is the Debug later version of testing that most developers are fond of. 
This is the testing that occurs when something breaks in your legacy code. 
You probably make a little supplemental main function that tests ***just*** the 
functions you need in ***just*** the right state for the very specific bug you are fixing. 
After some pain, and maybe hours of work, the bug is fixed, you take a deep sigh of 
relief and throw the little main function away forever. Never to look back until the next 
time something breaks and you go throw this painful cycle all over again.

### Test After
For developers new to unit testing I recommend this approach first. Really, what you should aim for is true TDD, but I think that this is a good way to get a feel for how unit testing works, why it is useful and should always be done. Unit Testing can be very complex and difficult when it's new, and that may turn some people away. 

This approach can either be done with legacy code or code you wrote yesterday that you just want to feel confident in. The point of adding the unit tests for a class is to make sure that the developer has full control, understanding, and confidence that a class is doing exactly what it was written to do. There shouldn't be any crazy things that happens because the class has fully been exhausted of its different path of execution. There should be a test for every single branch a function can go down. 

For any bugs that appear in the future, there should be a test written to make sure that does not occur again. These unit tests that are created are living documentation and alarms that let the developer know something went wrong. Any weird, special case, that caused a bug which you never anticipated, that is a test waiting to be written. 

### Test Driven Development (TDD)

TDD for me was a hard concept to buy in on. When someone mentioned testing your code automatically, I instantly agreed without question that it was brilliant and must be done. TDD I was skeptical for a long time on the way it is always taught and what it was trying to accomplish. It did not fully click until I read Grenning's book on TDD for Embedded C.

In TDD, the test is written before any code has been written. 
The test is expected to fail because no code has been written.
Then the easiest, simplest answer to make the test pass is written.
Finally the test is re-run, and hopefully your test passed.
