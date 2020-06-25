import { Movie } from "./movies.models";

export interface PaginatedMovies {
    currentPage: number;
    totalItems: number;
    itemsPerPage: number;
    totalPages: number;
    items: Movie[];
}
