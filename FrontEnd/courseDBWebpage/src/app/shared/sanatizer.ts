export function sanatize(input: string)
{
    //Filter out special symbols, leaves most languages intact.
    //Use before displaying user input
    var filtered = input.match(/[\p{L}\p{N}\s]/gu)?.join('');
    return filtered;
}