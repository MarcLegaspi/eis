export interface IPaginationData<T> {
    pageSize: number,
    pageIndex: number,
    count: number,
    data: T[]
}