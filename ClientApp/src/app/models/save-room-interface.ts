interface SaveRoom {
    id: number;
    name: string;
    buildingId: number;
    size: number;
    floor: number;
    types: {
        typeId: number,
        labTypeId: number
    }[];
}
