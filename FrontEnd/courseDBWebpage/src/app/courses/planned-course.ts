export interface PlannedCourse {
    id: number;

    duur: number;

    titel: string;

    code: string;
}

export function createPlannedCourse(overrides?: Partial<PlannedCourse>): PlannedCourse{
    return {
        id: -1,
        duur: -1,
        titel: "",
        code: "",
        ...overrides
    }
}

//TODO add course + startdate combination here as interface