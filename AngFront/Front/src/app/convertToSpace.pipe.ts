import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'convertToSpace'
})
    
export class ConvertToSpace implements PipeTransform{
    transform(value: any, character: string): string {
        return value.replace(character, '...');
    }
}