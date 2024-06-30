export interface GameResponseDTO {
    resultId: number;
    blackJackId: number | null;
    rouletteId: number | null;
    banditId: number | null;
    description: string;
    startDate: Date | string;
    endDate: Date | string;
    maxBet: number;
    minBet: number;
}