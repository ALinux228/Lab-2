open System

// Список из последних цифр чисел
let lastDigit list =
    List.map(fun x -> abs x % 10) list

// Сумма чисел с заданным последним числом
let sumLastDigit list digit =
    list 
    |> List.fold (fun acc x -> 
        if abs x % 10 = digit 
            then acc + x
        else acc) 0

// Проверка диапазона (цифра)
let rec validDigit() =

    let input = Console.ReadLine()

    match Int32.TryParse(input) with
    | true, number when number >= 0 && number <= 9 -> 
        number
    | _ -> 
        printfn "Введены неверные данные. Повторите ввод (0-9): "
        validDigit()

// Создание списка
let createList() =
    printf "Введите список чисел через пробел: "
    let input = Console.ReadLine()
    let listNumbers = 
        input.Split(' ') 
        |> Array.toList 
        |> List.filter (fun s -> s <> "") 
        |> List.map int

    printfn "Исходный список: %A" listNumbers
    listNumbers

[<EntryPoint>]
let main _ = 
    let list = createList()
 
    let lastDigits = lastDigit list
    printfn "Список последних цифр: %A" lastDigits

    printf "Введите цифру для суммирования чисел с указанной последней цифрой: "
    let number = int(validDigit())
    let sumLastDigits = sumLastDigit list number
    printfn "Сумма чисел: %d" sumLastDigits

    0