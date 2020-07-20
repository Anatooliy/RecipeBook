import { TreesNode } from './trees-node';

export class Recipe {
    constructor(public id: number,
                public name: string,
                public description: string,
                public namesTree: TreesNode[],
                public createdDate?: Date,
                public parentId?: number) {}  
}
