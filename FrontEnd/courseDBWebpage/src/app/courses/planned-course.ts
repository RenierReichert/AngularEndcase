import { PlannedCourse } from "../DTOs/CourseObjs"

export function createPlannedCourse(overrides?: Partial<PlannedCourse>): PlannedCourse{
    return {
        id: -1,
        duur: -1,
        titel: "",
        code: "",
        ...overrides
    }
}
