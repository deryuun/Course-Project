-> main

=== main ===
Hello, i am cube. Who are you? #speaker:Cube
    + [Hello, I am capsule!]
        -> chosenCapsule
    + [It's not your business]
        -> chosenNo
=== chosenCapsule ===
Nice to meet you!
- Nice to meet you too! #speaker:Capsule
-> END
=== chosenNo ===
I am just want to be your friend :(
- And I don't want. #speaker:Capsule
-> END