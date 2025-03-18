import express from 'express';
const express = require('express');
const renderApi = require('@api/render-api');

const app = express();

app.get('/services', async (req, res) => {
    try {
        renderApi.auth('rnd_lVFPbXqkEVHYTyqKwidsTtakBBXg'); // החלף את YOUR_API_KEY במפתח ה-API שלך
        const { data } = await renderApi.listServices({ includePreviews: 'true' });
        res.json(data);
    } catch (err) {
        console.error(err);
        res.status(500).json({ error: 'שגיאה פנימית בשרת' });
    }
});

const port = process.env.PORT || 3000;
app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});