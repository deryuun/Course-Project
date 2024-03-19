-> main

=== main ===
Hello, i am second. What is your name?
    + [Capsule]
        -> chosenCapsule
    + [Why are you asking?]
        -> chosenNo
=== chosenCapsule ===
Nice to meet you! Now we are friends!
    + [Nice to meet you too!!]
	-> chosen1
    + [Okay. Bye]
	-> chosen2
=== chosen1 ===
See you!
-> END
=== chosen2 ===
See you.
-> END
=== chosenNo ===
Because i want to be your friend :)
    + [Oh, I am Capsule!]
	-> chosen3
    + [But I don't want. Sorry]
	-> chosen4
=== chosen3 ===
Nice to meet you! See you!
-> END
=== chosen4 ===
As you know.
-> END